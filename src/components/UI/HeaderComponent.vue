<script setup>

import ButtonComponent from "@/components/UI/ButtonComponent.vue";
</script>

<template>
  <h1>Header</h1>
  <router-link to="/">Главная</router-link>
  <router-link to="/routes">Список роадмапов</router-link>
  <ButtonComponent text="Войти"></ButtonComponent>
  <ButtonComponent text="Регистрация"></ButtonComponent>
  <hr>
</template>
<style scoped>

</style>
