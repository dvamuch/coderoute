<script setup>

import FooterMenuComponent from "@/components/UI/FooterMenuComponent.vue";
import LogoComponent from "@/components/UI/LogoComponent.vue";
</script>

<template>
  <hr>
  <h1>Footer</h1>

  <LogoComponent></LogoComponent>

  <p>© 2023 CodeRoute. Все права защищены</p>

  <FooterMenuComponent title="О продукте" :menu-items="['Новости', 'Команда']"></FooterMenuComponent>
  <FooterMenuComponent title="Давайте общаться" :menu-items="['Наши контакты', 'GitHub']"></FooterMenuComponent>
</template>

<style scoped>

</style>
