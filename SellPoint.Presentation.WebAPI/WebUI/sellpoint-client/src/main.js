import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import "./styles/styles.scss";
import VueSweetalert2 from "vue-sweetalert2";
import "sweetalert2/dist/sweetalert2.min.css";
import VueSplash from "vue-splash";
import VueGoodTablePlugin from "vue-good-table-next";
import "vue-good-table-next/dist/vue-good-table-next.css";
import VueMask from "@devindex/vue-mask";
import moment from "moment";
import Maska from "maska";
import VueTheMask from "vue-the-mask";

const app = createApp(App);
app.use(VueTheMask);
app.use(Maska);
app.use(moment);
app.use(VueMask);
app.use(VueGoodTablePlugin);
app.use(VueSplash);
app.use(VueSweetalert2);
app.use(router);
app.mount("#app");
