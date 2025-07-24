<template>
  <div
    class="p-3 border rounded border-zinc-700 bg-zinc-900 max-w-[1200px] md:min-w-full"
  >
    <pv-data-table :value="documentPage?.items" :loading="loading">
      <template #empty>
        <div class="flex justify-center items-center space-x-1">
          <span>There are</span> <strong class="text-red-500"> NO </strong>
          <span>documents</span>
        </div>
      </template>
      <template #loading>
        <div class="flex justify-center items-center">
          <fragmented-loader></fragmented-loader>
        </div>
      </template>
      <template #header>
        <div class="flex justify-between">
          <div class="flex gap-2">
            <pv-button
              icon="bx bx-plus"
              label="Create"
              @click="openCreateDocumentDialog()"
            ></pv-button>
          </div>
          <div>
            <pv-icon-field>
              <pv-input-icon class="bx bx-search"></pv-input-icon>
              <pv-input-text
                v-model="searchTerm"
                @update:modelValue="debouncedUpdatePageFromSearchInput($event)"
                placeholder="Search"
              ></pv-input-text>
            </pv-icon-field>
          </div>
        </div>
      </template>
      <pv-column
        v-bind="column"
        v-for="(column, index) in columns"
        :key="index"
      >
        <template #body="{ data }" v-if="column.template">
          <component :is="column.template(data)"></component>
        </template>
      </pv-column>
      <pv-column>
        <template #body="slotProps">
          <div class="flex gap-2">
            <pv-button
              rounded
              severity="help"
              icon="bx bx-pencil"
              @click="openEditDocument(slotProps.data)"
            ></pv-button>
            <pv-button
              rounded
              severity="danger"
              icon="bx bx-trash"
              @click="openDeleteConfirmDialog(slotProps.data)"
            ></pv-button>
          </div>
        </template>
      </pv-column>
      <template #footer>
        <pv-paginator
          @page="updatePageFromPaginator($event)"
          v-model:first="first"
          v-model:pageLinkSize="pageLinkSize"
          :rows="rows"
          :rowsPerPageOptions="[5, 10, 20, 50]"
          :totalRecords="documentPage?.totalCount"
        ></pv-paginator>
      </template>
    </pv-data-table>
  </div>
</template>
<script lang="tsx" setup>
import { ref, watch, computed, type Ref, onMounted } from "vue";
import { useDialog } from "primevue/usedialog";

import { debounce } from "lodash";

// Dialog
import EditDocumentDialog from "../../dialogs/documents/edit-document-dialog.vue";
import type { Document } from "../../models/document";
import type { File } from "../../models/file";
import type { Pageable } from "../../types/pageable.interface";
import documentService from "../../services/document.service";
import CreateDocumentDialog from "../../dialogs/documents/create-document-dialog.vue";
import type { CreateDocument } from "../../types/documents/create-document.interface";

import FragmentedLoader from "../../components/loaders/fragmented-loader.vue";
import { useConfirm } from "primevue";

const documentPage: Ref<Pageable<Document> | null> = ref(null);

const loading = ref(true);
const confirm = useConfirm();

const columns = [
  { field: "id", header: "ID" },
  { field: "name", header: "Name" },
  { field: "description", header: "Description" },
  {
    header: "Created Date",
    field: "createdAt",
    template: (document: Document) => (
      <span>
        {new Date(document.createdAt).toLocaleDateString("en-US", {
          year: "numeric",
          day: "2-digit",
          month: "2-digit",
        })}
      </span>
    ),
  },
  {
    header: "Updated Date",
    field: "updatedAt",
    template: (document: Document) => (
      <span>
        {new Date(document.updatedAt).toLocaleDateString("en-US", {
          year: "numeric",
          day: "2-digit",
          month: "2-digit",
        })}
      </span>
    ),
  },
];

const rows = ref(5);
const page = ref(0);
const first = ref(0);
const total = ref(0);
const pageLinkSize = ref(4);
const dialog = useDialog();
const searchTerm = ref("");

function openDeleteConfirmDialog(data: Document) {
  confirm.require({
    async accept() {
      const response = (await documentService.deleteDocument(data.id)).data;
      documentPage.value = (
        await documentService.getDocumentsPerPage(page.value + 1, rows.value, searchTerm.value)
      ).data;
      console.log(response);
    },
    reject() {},
    acceptProps: {
      severity: "success",
    },
    rejectProps: {
      severity: "danger",
    },
    acceptLabel: "Ok",
    rejectLabel: "Cancel",
    acceptIcon: "bx bx-check",
    rejectIcon: "bx bx-x",
    message: `Are you sure you want to delete ${data.name}?`,
    icon: "bx bx-error",
    header: `Delete Confirmation`,
  });
}

function openEditDocument(document: Document) {
  const header = (
    <div>
      <h2 class="">Editing</h2>
      <small>{document.name}</small>
    </div>
  );

  dialog.open(EditDocumentDialog, {
    templates: {
      header,
    },
    props: {
      modal: true,
      style: {
        minWidth: "800px",
      },
    },
    data: {
      document: document,
    },
    async onClose(options) {
      console.log(page.value, rows.value);
      documentPage.value = (
        await documentService.getDocumentsPerPage(page.value, rows.value, "")
      ).data;
      console.log(options);
    },
  });
}

function openCreateDocumentDialog() {
  dialog.open(CreateDocumentDialog, {
    props: {
      modal: true,
      style: {
        minWidth: "500px",
      },
    },
    templates: {
      header: (
        <div class="flex flex-col">
          {" "}
          <span>Create Document</span>
        </div>
      ),
    },
    async onClose(options) {
      if (options && options.data) {
        const data: CreateDocument = options.data;
        await documentService.createDocument(data);
        console.log(page.value + 1, rows.value);
        documentPage.value = (
          await documentService.getDocumentsPerPage(
            page.value + 1,
            rows.value,
            searchTerm.value
          )
        ).data;
        loading.value = false;
      }
    },
  });
}

async function updatePageFromPaginator(event: {
  page: number;
  first: number;
  rows: number;
  pageCount: number;
}) {
  console.log("event1: ", event);
  page.value = event.page;
  rows.value = event.rows;
  documentPage.value = (
    await documentService.getDocumentsPerPage(
      event.page + 1,
      event.rows,
      searchTerm.value
    )
  ).data;
  loading.value = false;
}

async function updatePageFromSearchInput(event: string) {
  searchTerm.value = event;
  documentPage.value = (
    await documentService.getDocumentsPerPage(1, rows.value, event)
  ).data;
  total.value = documentPage.value?.totalCount!;
  loading.value = false;
}

const debouncedUpdatePageFromSearchInput = debounce((a: string) => {
  console.log(a);
  loading.value = false;
  updatePageFromSearchInput(a);
  loading.value = true;
}, 400);

async function getDocumentsPerPage() {
  documentPage.value = (
    await documentService.getDocumentsPerPage(1, rows.value, searchTerm.value)
  ).data;
  total.value = documentPage.value?.totalCount!;
  loading.value = false;
  console.log(total.value);
}

watch(first, (newVale, oldVale) => {
  console.log(newVale);
});

watch(pageLinkSize, (newVale, oldVale) => {
  console.log(newVale);
});

watch(pageLinkSize, (newVale, oldVale) => {
  console.log(newVale);
});

onMounted(async () => {
  getDocumentsPerPage();
});
</script>
<style scoped></style>
