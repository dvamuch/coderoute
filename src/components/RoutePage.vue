<script setup>
import MainNodeComponent from "@/components/UI/MainNodeComponent.vue";

const mainNodes = [
  {
    title: "Интернет",
    status: "finished",
    secondaryNodes: [{title: "Как работает интернет?", status: "finished"}, {
      title: "Что такое HTTP?",
      status: "finished",
    }],
  },
];

</script>

<template>
  <h1>Дорожная карта {{ $route.params.id }}</h1>
  <p>Специалист, отвечающий за создание пользовательского интерфейса сайта, приложения или ПО</p>
  <hr>
  <MainNodeComponent v-for="mainNode in mainNodes" v-bind:key="mainNode.title" :title="mainNode.title"
                     :status="mainNode.status"
                     :secondary-nodes="mainNode.secondaryNodes"></MainNodeComponent>
</template>

<style scoped>

</style>
