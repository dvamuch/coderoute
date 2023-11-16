<script setup>
const props = defineProps({
  text: {
    type: String,
    required: true,
  },
});
</script>

<template>

  <li><a href="#" class="listItem">{{ props.text}}</a></li>

</template>

<style scoped>

</style>
