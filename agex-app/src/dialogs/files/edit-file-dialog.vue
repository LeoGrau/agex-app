<template>
  <pv-form
    v-slot="$form"
    :initialValues="initialValues"
    @submit="onFormSubmit($event)"
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
const params = dialogRef?.value.data
const fileId = ref(params.fileId)

const file = ref()

const initialValues = reactive({
  name: "",
  url: "",
  description: ""
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
    label: "URL",
    key: "url",
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

function onFormSubmit(event: any) {
  console.log("event", event);
  dialogRef?.value.close()
}

function setFields() {
  initialValues.name = file.value.name
  initialValues.url = file.value.url
  initialValues.description = file.value.description
}

onMounted(async () => {
  file.value = (await fileService.getFileById(fileId.value)).data
  setFields()
  console.log(file.value)
})
</script>
<style lang=""></style>
