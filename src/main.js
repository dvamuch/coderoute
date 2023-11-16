import {createApp} from "vue";
import App from "./App.vue";
import {router} from "./router";
import {createPinia} from "pinia";
import clickOutDirective from "@/directives/clickOut";

const pinia = createPinia();
const app = createApp(App);

app.use(router);
app.use(pinia);
app.directive("click-out", clickOutDirective);
app.mount("#app");

