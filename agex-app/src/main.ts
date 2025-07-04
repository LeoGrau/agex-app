import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";

// Icons
import 'boxicons/css/boxicons.css';

// Primevue
import PrimeVue from "primevue/config";
import Aura from "@primeuix/themes/aura";

// Components
import DataTable from "primevue/datatable";
import Column from "primevue/column";
import Paginator from "primevue/paginator";
import Button from "primevue/button"
import InputText from "primevue/inputtext";
import IconField from 'primevue/iconfield';
import InputIcon from 'primevue/inputicon';
import DynamicDialog from "primevue/dynamicdialog"
import FloatLabel  from "primevue/floatlabel";
import Form from "@primevue/forms/form"
import Textarea from "primevue/textarea";
import Tabs  from "primevue/tabs";
import Tab from "primevue/tab"
import TabList from "primevue/tablist"
import TabPanel from "primevue/tabpanel"
import TabPanels from "primevue/tabpanels"

// Service
import DialogService from "primevue/dialogservice";

// Directive
import Ripple from 'primevue/ripple';

// Routing
import router from "./router";



var app = createApp(App);

var root = document.getElementsByTagName("html")[0];
root.classList.toggle("dark")
console.log(root);

// document.documentElement.setAttribute("data-theme", "dark")

// Themees
app.use(PrimeVue, {
  ripple: true,
  theme: {
    preset: Aura,
  },
});

console.log(import.meta.env)

// Components
app.component("pv-data-table", DataTable);
app.component("pv-column", Column);
app.component("pv-paginator", Paginator);
app.component("pv-button", Button)
app.component("pv-input-text", InputText)
app.component("pv-icon-field", IconField)
app.component("pv-input-icon", InputIcon)
app.component("pv-dynamic-dialog", DynamicDialog)
app.component("pv-float-label", FloatLabel)
app.component("pv-form", Form)
app.component("pv-text-area", Textarea)
app.component("pv-tab-panel", TabPanel)
app.component("pv-tab-panels", TabPanels)
app.component("pv-tabs", Tabs)
app.component("pv-tab", Tab)
app.component("pv-tab-list", TabList)


// Ripple
app.directive('ripple', Ripple);


// Use
app.use(router);
app.use(DialogService)

app.mount("#app");
