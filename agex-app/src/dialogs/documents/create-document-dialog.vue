<template>
  <div>
    <pv-form
      @submit="onOkButton"
      v-slot="$form"
      :resolver
      :initialValues="initialValues"
    >
      <div class="flex flex-col gap-7 pt-6">
        <pv-float-label v-for="(field, index) in fieldInputs" :key="index">
          <component
            :name="field.key"
            :is="field.componentName"
            :invalid="$form[field.key]?.invalid"
            fluid
          ></component>
          <label for="">{{ field.label }}</label>
        </pv-float-label>
      </div>
      <div class="flex justify-end gap-2 mt-4">
        <pv-button
          type="submit"
          label="Ok"
          severity="success"
          icon="bx bx-save"
        ></pv-button>
        <pv-button
          label="Cancel"
          severity="danger"
          icon="bx bx-x"
          @click="onCancelButton"
        ></pv-button>
      </div>
    </pv-form>
  </div>
</template>
<script setup lang="tsx">
import type { DynamicDialogInstance } from "primevue/dynamicdialogoptions";
import { inject, reactive, ref, type Ref } from "vue";
import type { CreateDocument } from "../../types/documents/create-document.interface";

const dialogRef = inject<Ref<DynamicDialogInstance>>("dialogRef");

const initialValues = reactive({
  name: "",
  description: "",
} as any);

const resolver = ({ values }: { values: any }) => {
  const errors: any = {};
  console.log(values);
  if (!values.name) {
    errors.name = [{ message: "Name is required" }];
  }
  if (!values.description) {
    errors.description = [{ message: "Description is required" }];
  }
  return { values, errors };
};

const fieldInputs = ref([
  {
    label: "Name",
    key: "name",
    componentName: "pv-input-text",
  },
  {
    label: "Description",
    key: "description",
    componentName: "pv-text-area",
  },
]);

function onOkButton(form: any) {
  console.log(form);
  if (form.valid) {
    var createDocument: CreateDocument = {
      name: form.values.name,
      description: form.values.description,
    };
    dialogRef?.value.close(createDocument);
  }
}

function onCancelButton() {
  dialogRef?.value.close();
}
</script>
<style scoped></style>
