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
import { reactive, ref } from "vue";

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
}
</script>
<style lang=""></style>
