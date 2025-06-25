<template>
  <nav
    class="text-white bg-clip-padding dark:bg-neutral/20 border-x border-b isolate ring-1 ring-black/5 border-gray-500/20 rounded-b-md h-[70px] backdrop-blur-[2px] shadow-2xl fixed top-0 w-full z-50"
  >
    <div class="w-full h-full flex items-center justify-between px-5">
      <section>
        <h1 class="text-2xl">Agex</h1>
      </section>
      <section>
        <ul class="flex gap-3">
          <li v-for="(item, index) in items" :key="index">
            <span>{{ item.label }}</span>
          </li>
        </ul>
      </section>
    </div>
  </nav>
</template>
<script lang="ts" setup>
// Frontend variables
const items = [
  {
    name: "name",
    label: "Home",
    to: "path",
  },
  {
    name: "name",
    label: "Documents",
    to: "path",
  },
  {
    name: "name",
    label: "",
    to: "path",
  }
];
</script>
<style scoped></style>
