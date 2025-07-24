<template>
  <div>
    <pv-form
      ref="formRef"
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
        <pv-button type="submit" label="Ok" severity="success" icon="bx bx-save"></pv-button>
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
import { inject, onMounted, reactive, ref, type Ref } from "vue";
import type { CreateFile } from "../../types/files/create-file.interface";

const dialogRef = inject<Ref<DynamicDialogInstance>>("dialogRef");
const documentId = dialogRef?.value.data.documentId
const formRef = ref()
const params = dialogRef?.value.data;

const initialValues = reactive({
  name: "",
  description: "",
  url: "",
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
  if (!values.url) {
    errors.url = [{ message: "Description is required" }];
  }
  return { errors, values };
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
    componentName: "pv-input-text",
  },
  {
    label: "URL",
    key: "url",
    componentName: "pv-input-text",
  },
]);

function onOkButton(form: any) {
  if (form.valid) {
    console.log(form.values)
    const newFile: CreateFile = {
      name: form.values.name,
      description: form.values.description,
      url: form.values.url,
      documentId
    };
    dialogRef?.value.close(newFile);
  }
}

function onCancelButton() {
  dialogRef?.value.close();
}

onMounted(() => {
  console.log("fuag",documentId)
})
</script>
<style scoped></style>
