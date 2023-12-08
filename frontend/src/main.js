import clickOutDirective from "@/directives/clickOut";
import {createPinia} from "pinia";
import {createApp} from "vue";
import VueMobileDetection from "vue-mobile-detection";
import App from "./App.vue";
import router from "./router";

const app = createApp(App);
const pinia = createPinia();

app.use(pinia);
app.use(router);
app.use(VueMobileDetection);
app.directive("click-out", clickOutDirective);
app.mount("#app");

