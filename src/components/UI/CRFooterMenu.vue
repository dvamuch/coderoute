<script setup>
import FooterMenuItemComponent from "@/components/UI/CRFooterMenuItem.vue";

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
  <ul class="rightList flexibleY">
    <li><h3 class="listItem title">{{ props.title }}</h3></li>
    <FooterMenuItemComponent v-for="menuItem in props.menuItems" :key="menuItem" :text="menuItem"></FooterMenuItemComponent>
  </ul>

</template>
