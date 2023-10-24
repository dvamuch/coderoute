<script setup>
import FooterMenuItemComponent from "@/components/UI/FooterMenuItemComponent.vue";

const props = defineProps({
  title: {
    type: String,
    required: true,
  },
  menuItems: {
    type: Array,
    required: true,
  },
});
</script>

<template>

  <h4>{{ props.title }}</h4>

  <div>
    <FooterMenuItemComponent v-for="menuItem in props.menuItems" :key="menuItem" :text="menuItem"></FooterMenuItemComponent>
  </div>

</template>

<style scoped>

</style>
