<script setup>

import ButtonComponent from "@/components/UI/ButtonComponent.vue";
</script>

<template>
  <h1>Header</h1>
  <ButtonComponent text="Я кнопка"></ButtonComponent>
  <router-link to="/">Главная</router-link>
  <router-link to="/routes">Список роадмапов</router-link>
  <hr>
</template>
<style scoped>

</style>
