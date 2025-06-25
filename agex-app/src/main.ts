import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";

// Primevue
import PrimeVue from "primevue/config";
import Aura from "@primeuix/themes/aura";

// Components
import DataTable from "primevue/datatable";
import Column from "primevue/column";
import Paginator from "primevue/paginator";
import Button from "primevue/button"

// Routing
import router from "./router";

var app = createApp(App);

var root = document.getElementsByTagName("html")[0];
root.classList.toggle("dark")
console.log(root);

// document.documentElement.setAttribute("data-theme", "dark")

// Themees
app.use(PrimeVue, {
  theme: {
    preset: Aura,
  },
});

// Components
app.component("pv-data-table", DataTable);
app.component("pv-column", Column);
app.component("pv-paginator", Paginator);
app.component("pv-button", Button)

// Use
app.use(router);

app.mount("#app");
