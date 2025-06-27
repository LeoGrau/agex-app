<template>
  <div
    class="p-3 border rounded border-zinc-700 bg-zinc-900 max-w-[1200px] md:min-w-full"
  >
    <pv-data-table :value="itemsCom">
      <template #header>
        <div class="flex justify-between">
          <div class="flex gap-2">
            <pv-button icon="bx bx-plus" label="Create"></pv-button>
          </div>
          <div>
            <pv-icon-field>
              <pv-input-icon class="bx bx-search"></pv-input-icon>
              <pv-input-text placeholder="Search"></pv-input-text>
            </pv-icon-field>
          </div>
        </div>
      </template>
      <pv-column></pv-column>
      <pv-column
        v-bind="column"
        v-for="(column, index) in columns"
        :key="index"
      ></pv-column>
      <pv-column>
        <template #body="slotProps">
          <div class="flex gap-2">
            <pv-button
              rounded
              severity="help"
              icon="bx bx-pencil"
              @click="openEditDocument(slotProps.data)"
            ></pv-button>
          </div>
        </template>
      </pv-column>
      <template #footer>
        <pv-paginator
          v-model:first="first"
          v-model:pageLinkSize="pageLinkSize"
          :rows="rows"
          :rowsPerPageOptions="[5, 10, 20, 50]"
          :totalRecords="20"
        ></pv-paginator>
      </template>
    </pv-data-table>
  </div>
</template>
<script lang="tsx" setup>
import { ref, watch, computed } from "vue";
import { useDialog } from "primevue/usedialog";

// Dialog
import EditDocumentDialog from "../../dialogs/documents/edit-document-dialog.vue";
import type { Document } from "../../models/document";
import type { File } from "../../models/file";

const documents: Document[] = [
  {
    id: 1,
    name: "Documento A",
    description: "Descripción del documento A",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 2,
    name: "Documento B",
    description: "Descripción del documento B",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 3,
    name: "Documento C",
    description: "Documento relacionado a clientes",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 4,
    name: "Documento D",
    description: "Informe financiero trimestral",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 5,
    name: "Documento E",
    description: "Resumen ejecutivo del proyecto",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 6,
    name: "Documento F",
    description: "Plan estratégico anual",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 7,
    name: "Documento G",
    description: "Acta de reunión interna",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 8,
    name: "Documento H",
    description: "Propuesta de mejora continua",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 9,
    name: "Documento I",
    description: "Manual técnico de implementación",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 10,
    name: "Documento J",
    description: "Documento de capacitación",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 11,
    name: "Documento K",
    description: "Reglamento interno actualizado",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 12,
    name: "Documento L",
    description: "Procedimientos operativos estándar",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 13,
    name: "Documento M",
    description: "Reporte de indicadores clave",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 14,
    name: "Documento N",
    description: "Análisis de riesgo del sistema",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 15,
    name: "Documento O",
    description: "Bitácora de cambios",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 16,
    name: "Documento P",
    description: "Política de seguridad de la información",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 17,
    name: "Documento Q",
    description: "Guía de uso del sistema",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 18,
    name: "Documento R",
    description: "Checklist de verificación",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 19,
    name: "Documento S",
    description: "Cronograma del proyecto",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 20,
    name: "Documento T",
    description: "Informe de auditoría interna",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 21,
    name: "Documento U",
    description: "Evaluación de desempeño anual",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 22,
    name: "Documento V",
    description: "Estudio de mercado preliminar",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
  {
    id: 23,
    name: "Documento W",
    description: "Registro de incidentes técnicos",
    files: [
      { url: "url1", name: "name1" } as File,
      { url: "url2", name: "name2" } as File,
    ]
  } as Document,
];
const columns = [
  { field: "id", header: "ID" },
  { field: "name", header: "Name" },
  { field: "description", header: "Description" },
];

defineProps({
  size: { type: Number, default: 24 },
  color: { type: String, default: "#000000" },
});

const rows = ref(5);
const first = ref(0);
const pageLinkSize = ref(4);
const dialog = useDialog();

const itemsCom = computed(() =>
  documents.slice(first.value, first.value + rows.value)
);

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
    },
    data: {
      document: document
    }
  });
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
</script>
<style scoped></style>
