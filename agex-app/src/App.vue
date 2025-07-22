<template>
  <div class="h-full w-full">
    <pv-dynamic-dialog></pv-dynamic-dialog>
    <agex-toolbar></agex-toolbar>
    <div class="h-full w-full flex justify-center items-center" v-if="isRouteLoading">
      <fragmented-loader></fragmented-loader>
    </div>
    <div v-else>
      <router-view class="translate-y-[70px] p-8"></router-view>
    </div>
  </div>
</template>
<script lang="ts" setup>
import { onMounted, ref } from "vue";
import AgexToolbar from "../src/components/agex-toolbar.vue";
import router from "./router";
import FragmentedLoader from "./components/loaders/fragmented-loader.vue";

const isRouteLoading = ref(false);

onMounted(() => {
  router.beforeEach((to, from, next) => {
    isRouteLoading.value = true;
    next();
  });

  router.afterEach(() => {
    setTimeout(() => {
      isRouteLoading.value = false;
    }, 200);
  });
});
</script>
<style scoped></style>
