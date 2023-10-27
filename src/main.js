import MainPage from "@/components/MainPage.vue";
import RouteListPage from "@/components/RouteListPage.vue";
import RoutePage from "@/components/RoutePage.vue";
import {createApp} from "vue";
import App from "./App.vue";
import {createRouter, createWebHashHistory} from "vue-router";


const routes = [
  {path: "/", component: MainPage},
  {path: "/routes", component: RouteListPage},
  {path: "/routes/:id", component: RoutePage},
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

const app = createApp(App);

app.use(router);
app.mount("#app");
