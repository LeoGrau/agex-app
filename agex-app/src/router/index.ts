import {
  createRouter,
  createWebHistory,
  type RouteRecordRaw,
} from "vue-router";

import HomeView from "../pages/home/home-view.vue";
import DocumentsView from "../pages/documents/documents-view.vue";

// const routes: RouteRecordRaw[] = [
//   { path: "/", name: "home-view", component: HomeView },
//   { path: "/home", redirect: { name: 'home-view' } },
//   { path: "/documents", name: "documents-view", component: DocumentsView },
// ];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    { path: "/", name: "home-view", component: HomeView },
    { path: "/documents", name: "documents-view", component: DocumentsView },
    { path: "/home", redirect: { name: "home-view" } },
  ],
});

export default router;
