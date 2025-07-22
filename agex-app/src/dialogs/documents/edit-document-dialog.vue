<template>
  <div>
    <pv-tabs value="0">
      <pv-tab-list>
        <pv-tab value="0">Files</pv-tab>
        <pv-tab value="1">Information</pv-tab>
      </pv-tab-list>
      <pv-tab-panels>
        <pv-tab-panel value="0">
          <pv-data-table :value="filePage?.items">
            <template #header>
              <div class="flex justify-between">
                <pv-button
                  severity="success"
                  label="Create File"
                  @click="openCreateFileDialog()"
                  icon="bx bx-plus"
                ></pv-button>
                <pv-icon-field>
                  <pv-input-icon class="bx bx-search"></pv-input-icon>
                  <pv-input-text
                    @update:modelValue="debouncedUpdatePageFromSearchInput($event)"
                    v-model="searchTerm"
                    placeholder="Search"
                  ></pv-input-text>
                </pv-icon-field>
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
            <pv-column header="Actions">
              <template #body="{ data }">
                <div class="flex gap-2">
                  <pv-button
                    rounded
                    severity="help"
                    icon="bx bx-pencil"
                    @click="openEditFileDialog(data)"
                  ></pv-button>
                  <pv-button
                    rounded
                    severity="danger"
                    icon="bx bx-trash"
                  ></pv-button>
                </div>
              </template>
            </pv-column>
            <template #footer>
              <pv-paginator
                @page="updatePageFromPaginator($event)"
                :rowsPerPageOptions="[5, 10, 20, 50]"
                :totalRecords="filePage?.totalCount"
                :rows="rows"
              ></pv-paginator>
            </template>
          </pv-data-table>
        </pv-tab-panel>
        <pv-tab-panel value="1">
          <div>
            <div class="flex flex-col">
              <pv-form
                @submit="onOkButton"
                v-slot="$form"
                :initialValues="initialValues"
                class="flex flex-col justify-between gap-3"
              >
                <div class="pt-6 flex flex-col gap-8">
                  <pv-float-label v-for="(input, index) in inputs" :key="index">
                    <component
                      :is="input.componentName"
                      fluid
                      :name="input.key"
                      v-model="initialValues[input.key]"
                      :invalid="input.invalid(initialValues[input.key])"
                    ></component>
                    <label>{{ input.label }}</label>
                  </pv-float-label>
                </div>
                <div class="flex justify-end gap-2">
                  <pv-button
                    severity="success"
                    type="submit"
                    label="Ok"
                    icon="bx bx-save"
                  ></pv-button>
                  <pv-button
                    severity="danger"
                    type="submit"
                    label="Cancel"
                    icon="bx bx-x"
                  ></pv-button>
                </div>
              </pv-form>
            </div>
          </div>
        </pv-tab-panel>
      </pv-tab-panels>
    </pv-tabs>
  </div>
</template>
<script lang="tsx" setup>
import { inject, onMounted, reactive, ref, type Ref } from "vue";
import { Document } from "../../models/document";
import type { DynamicDialogInstance } from "primevue/dynamicdialogoptions";
import type { File } from "../../models/file";
import documentService from "../../services/document.service";
import fileService from "../../services/file.service";
import type { Pageable } from "../../types/pageable.interface";
import { useDialog } from "primevue";
import EditFileDialog from "../files/edit-file-dialog.vue";
import CreateFileDialog from "../files/create-file-dialog.vue";
import type { CreateFile } from "../../types/files/create-file.interface";
import { debounce } from "lodash";

interface EditDocumentDialogProps {
  document: Document;
}

const dialogRef = inject<Ref<DynamicDialogInstance>>("dialogRef");
const params = ref(dialogRef?.value.data);
const documentId = ref(params.value.document.id);
const rows = ref(5);
const document: Ref<Document | null> = ref(null);
const total = ref(0);
const searchTerm = ref("");
const pageIndex = ref();
const filePage: Ref<Pageable<File> | null> = ref(null);

const dialog = useDialog();

// Inputs

const initialValues = reactive({
  name: "",
  description: "",
} as any);

const inputs = ref([
  {
    label: "Name",
    key: "name",
    value: "",
    componentName: "pv-input-text",
    invalid: (value: any) => !value,
  },
  {
    label: "Description",
    key: "description",
    value: "",
    componentName: "pv-text-area",
    invalid: (value: any) => !value,
  },
]);

// Table
const columns = [
  {
    header: "URL",
    field: "url",
    template: (file: File) => (
      <a
        href={file.url}
        class="flex items-center gap-2 hover:border-b w-fit border-indigo-500 pb-1"
      >
        <i class="bx bx-link text-indigo-500"></i>
        <a class="text-indigo-500">Link</a>
      </a>
    ),
  },
  {
    header: "Name",
    field: "name",
    template: null,
  },
  {
    header: "Created Date",
    field: "createdAt",
    template: (file: File) => (
      <span>
        {new Date(file.createdAt).toLocaleDateString("en-US", {
          year: "numeric",
          day: "2-digit",
          month: "2-digit",
        })}
      </span>
    ),
  },
];

async function updatePageFromPaginator(event: {
  page: number;
  first: number;
  rows: number;
  pageCount: number;
}) {
  filePage.value = (
    await fileService.getFilesByDocumentIdPerPage(
      event.page + 1,
      event.rows,
      searchTerm.value,
      documentId.value
    )
  ).data;
}

async function updatePageFromSearchInput(event: any) {
  filePage.value = (
    await fileService.getFilesByDocumentIdPerPage(
      1,
      rows.value,
      event,
      documentId.value
    )
  ).data;
  total.value = filePage.value?.totalCount!;
}

const debouncedUpdatePageFromSearchInput = debounce((event: any) => {
  console.log(event)
  updatePageFromSearchInput(event);
}, 400);

async function getFilesByDocumentIdPerPage() {
  filePage.value = (
    await fileService.getFilesByDocumentIdPerPage(
      1,
      rows.value,
      searchTerm.value,
      documentId.value
    )
  ).data;
  total.value = filePage.value?.totalCount!;
}

function openEditFileDialog(file: File) {
  dialog.open(EditFileDialog, {
    templates: {
      header: (
        <div class="flex flex-col gap-2">
          <span>Edit File</span>
          <small>{file.name}</small>
        </div>
      ),
    },
    data: {
      fileId: file.id,
    },
    props: {
      modal: true,
      style: {
        minWidth: "500px",
      },
    },
  });
}

function openCreateFileDialog() {
  dialog.open(CreateFileDialog, {
    templates: {
      header: (
        <div class="flex flex-col gap-2">
          <span>Create File</span>
        </div>
      ),
    },
    props: {
      modal: true,
      style: {
        minWidth: "500px",
      },
    },
    data: {
      documentId,
    },
    async onClose(options) {
      if (options && options.data) {
        const data: CreateFile = options.data;
        const response = await fileService.createFile(data);
        const updateFilesResponse =
          await fileService.getFilesByDocumentIdPerPage(
            1,
            rows.value,
            "",
            documentId.value
          );
        filePage.value = updateFilesResponse.data;

        console.log(updateFilesResponse.data.items);
      }
    },
  });
}

function onOkButton(form: any) {
  if (form.valid) {
    console.log("Wuaj", form.values);
    documentService.updateDocument(documentId.value, form.values);
  }
}

function onCancelButton() {}

function setFields() {
  if (document.value) {
    initialValues.name = document.value.name;
    initialValues.description = document.value.description;
  }
}

onMounted(async () => {
  console.log(params.value);

  document.value = (await documentService.getDocument(documentId.value)).data;
  await setFields();
  getFilesByDocumentIdPerPage();
  console.log(document);
});
</script>
<style scoped></style>
