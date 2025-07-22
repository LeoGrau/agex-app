<template>
  <div>
    <pv-form :initialValues="initialValues">
      <div class="flex flex-col gap-7 pt-6">
        <pv-float-label v-for="(field, index) in fieldInputs" :key="index">
          <component
            v-model="initialValues[field.key]"
            :name="field.key"
            :is="field.componentName"
            fluid
            :invalid="field.invalid(initialValues[field.key])"
          ></component>
          <label for="">{{ field.label }}</label>
        </pv-float-label>
      </div>
      <div class="flex justify-end gap-2 mt-4">
        <pv-button label="Ok" severity="success" icon="bx bx-save" @click="onOkButton"></pv-button>
        <pv-button label="Cancel" severity="danger" icon="bx bx-x" @click="onCancelButton"></pv-button>
      </div>
    </pv-form>
  </div>
</template>
<script setup lang="tsx">
import type { DynamicDialogInstance } from "primevue/dynamicdialogoptions";
import { inject, reactive, ref, type Ref } from "vue";
import type { CreateFile } from "../../types/files/create-file.interface";

const dialogRef = inject<Ref<DynamicDialogInstance>>("dialogRef");
const params = dialogRef?.value.data;

const initialValues = reactive({
  name: "",
  description: "",
  url: "",
} as any);

const fieldInputs = ref([
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
    componentName: "pv-input-text",
    invalid: (value: any) => !value,
  },
  {
    label: "URL",
    key: "url",
    value: "",
    componentName: "pv-input-text",
    invalid: (value: any) => !value,
  },
]);

function onOkButton() {
  const newFile : CreateFile = {
    name: initialValues.name,
    description: initialValues.description,
    url: initialValues.url,
    documentId: params.documentId
  }
  dialogRef?.value.close(newFile)
}

function onCancelButton() {
  dialogRef?.value.close();
}


</script>
<style scoped></style>
