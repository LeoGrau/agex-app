<template>
  <div class="p-3">
    <pv-data-table :value="itemsCom">
      <pv-column></pv-column>
      <pv-column
        v-bind="column"
        v-for="(column, index) in columns"
        :key="index"
      ></pv-column>
      <pv-column>
        <template #body>
          <div class="flex gap-2">wow</div>
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
<script lang="ts" setup>
import { ref, watch, computed } from "vue";
const documents = [
  { id: 1, name: "Documento A", description: "Descripción del documento A" },
  { id: 2, name: "Documento B", description: "Descripción del documento B" },
  {
    id: 3,
    name: "Documento C",
    description: "Documento relacionado a clientes",
  },
  { id: 4, name: "Documento D", description: "Informe financiero trimestral" },
  { id: 5, name: "Documento E", description: "Resumen ejecutivo del proyecto" },
  { id: 6, name: "Documento F", description: "Plan estratégico anual" },
  { id: 7, name: "Documento G", description: "Acta de reunión interna" },
  { id: 8, name: "Documento H", description: "Propuesta de mejora continua" },
  {
    id: 9,
    name: "Documento I",
    description: "Manual técnico de implementación",
  },
  { id: 10, name: "Documento J", description: "Documento de capacitación" },
  {
    id: 11,
    name: "Documento K",
    description: "Reglamento interno actualizado",
  },
  {
    id: 12,
    name: "Documento L",
    description: "Procedimientos operativos estándar",
  },
  { id: 13, name: "Documento M", description: "Reporte de indicadores clave" },
  {
    id: 14,
    name: "Documento N",
    description: "Análisis de riesgo del sistema",
  },
  { id: 15, name: "Documento O", description: "Bitácora de cambios" },
  {
    id: 16,
    name: "Documento P",
    description: "Política de seguridad de la información",
  },
  { id: 17, name: "Documento Q", description: "Guía de uso del sistema" },
  { id: 18, name: "Documento R", description: "Checklist de verificación" },
  { id: 19, name: "Documento S", description: "Cronograma del proyecto" },
  { id: 20, name: "Documento T", description: "Informe de auditoría interna" },
  { id: 21, name: "Documento U", description: "Evaluación de desempeño anual" },
  { id: 22, name: "Documento V", description: "Estudio de mercado preliminar" },
  {
    id: 23,
    name: "Documento W",
    description: "Registro de incidentes técnicos",
  },
];
const columns = [
  { field: "id", header: "ID" },
  { field: "name", header: "Name" },
  { field: "description", header: "Description" },
];

const rows = ref(5);
const first = ref(10);
const pageLinkSize = ref(4);

const itemsCom = computed(() =>
  documents.slice(first.value, first.value + rows.value)
);

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
