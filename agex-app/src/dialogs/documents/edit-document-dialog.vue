<template>
  <div>
    <pv-data-table :value="files">
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
            <pv-button rounded severity="help" icon="bx bx-pencil"></pv-button>
            <pv-button rounded severity="danger" icon="bx bx-trash"></pv-button>
          </div>
        </template>
      </pv-column>
      <template #footer>
        <pv-paginator
          :rowsPerPageOptions="[5, 10, 20, 50]"
          :totalRecords="totalRecords"
          :rows="rows"
        ></pv-paginator>
      </template>
    </pv-data-table>
  </div>
</template>
<script lang="tsx" setup>
import { inject, onMounted, ref, type Ref } from "vue";
import { Document } from "../../models/document";
import type { DynamicDialogInstance } from "primevue/dynamicdialogoptions";
import type { File } from "../../models/file";

interface EditDocumentDialogProps {
  document: Document;
}

const dialogRef = inject<Ref<DynamicDialogInstance>>("dialogRef");
const params = ref(dialogRef?.value.data);

const rows = ref(5);
const document = ref({ ...params.value.document } as Document);
const totalRecords = ref(document.value.files.length);
const files = ref(document.value.files);

// Table
const columns = [
  {
    header: "URL",
    field: "url",
    template: (file: File) => (
      <a href={file.url} class="flex items-center gap-2 hover:border-b w-fit border-indigo-500 pb-1">
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
];

onMounted(() => {
  console.log(params.value.document.files.length);
  console.log(files.value);
});
</script>
<style scoped></style>
