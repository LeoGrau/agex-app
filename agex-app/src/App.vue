<template>
  <div>
    <pv-dynamic-dialog></pv-dynamic-dialog>
    <agex-toolbar></agex-toolbar>
    <router-view class="translate-y-[70px] p-8"></router-view>
  </div>
</template>
<script lang="ts" setup>
import AgexToolbar from "../src/components/agex-toolbar.vue"

</script>
<style scoped>
  
</style>