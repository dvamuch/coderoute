<script setup>

import CRMainNode from "@/components/UI/CRMainNode.vue";
import CRNodeModalPopup from "@/components/UI/CRNodeModalPopup.vue";
import {computed, ref} from "vue";
import {useRoute} from "vue-router";
import {useAppStore} from "@/stores/app";

const appStore = useAppStore();
const showModal = computed(() => appStore.showModal);
const route = useRoute();


const nodes = [
  {
    id: 1,
    title: "Интернет",
    status: "finished",
    secondaryNodes: [
      {
        id: 2, title: "Как работает интернет?", status: "finished",
      }, {
        id: 3,
        title: "Что такое HTTP?",
        status: "finished",
      }],
  },
];

const routeId = computed(() => route.params.id);

let nodePopupObject = ref({});


</script>

<template>
  <h1>Дорожная карта {{ routeId }}</h1>
  <p>Специалист, отвечающий за создание пользовательского интерфейса сайта, приложения или ПО</p>
  <hr>
  <CRMainNode v-for="mainNode in nodes" v-bind:key="mainNode.id" :node="mainNode"></CRMainNode>
  <CRNodeModalPopup v-if="showModal" :node="nodePopupObject"></CRNodeModalPopup>
</template>

