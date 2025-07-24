<template>
  <pv-form
    ref="formRef"
    :resolver
    v-slot="$form"
    :initialValues="initialValues"
    @submit="onFormSubmit($event)"
    class="flex flex-col justify-between gap-3"
  >
    <div class="pt-6 flex flex-col gap-8">
      <pv-float-label v-for="(input, index) in inputs" :key="index">
        <component
          :is="input.componentName"
          :name="input.key"
          :invalid="$form[input.key]?.invalid"
          fluid
        ></component>
        <label>{{ input.label }}</label>
      </pv-float-label>
    </div>
    <div class="flex justify-end gap-2">
      <pv-button
        @click=""
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
</template>
<script setup lang="tsx">
import type { DynamicDialogInstance } from "primevue/dynamicdialogoptions";
import { inject, onMounted, reactive, ref, type Ref } from "vue";
import fileService from "../../services/file.service";

const dialogRef = inject<Ref<DynamicDialogInstance>>("dialogRef");
const params = dialogRef?.value.data;
const fileId = ref(params.fileId);

const file = ref();
const formRef = ref();

const resolver = ({ values }: { values: any }) => {
  const errors: any = {};
  console.log(values);
  if (!values.name) {
    errors.name = [{ message: "Name is required" }];
  }
  if (!values.url) {
    errors.url = [{ message: "URL is required" }];
  }
  if (!values.description) {
    errors.description = [{ message: "Description is required" }];
  }
  return {
    errors
  }
};

const initialValues = reactive({
  name: "",
  url: "",
  description: "",
} as any);

const inputs = ref([
  {
    label: "Name",
    key: "name",
    componentName: "pv-input-text",
  },
  {
    label: "URL",
    key: "url",
    componentName: "pv-input-text",
  },
  {
    label: "Description",
    key: "description",
    componentName: "pv-text-area",
  },
]);

function onFormSubmit(event: any) {
  console.log("event", event);
  if (event.valid) {
    dialogRef?.value.close();
  }
}

function setFields() {
  formRef.value.setValues({
    name: file.value.name,
    url: file.value.url,
    description: file.value.description,
  });
}

onMounted(async () => {
  file.value = (await fileService.getFileById(fileId.value)).data;
  setFields();
  console.log(file.value);
});
</script>
<style lang=""></style>
