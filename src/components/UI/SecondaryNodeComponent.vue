<script setup>
const props = defineProps({
  title: {
    type: String,
    required: true,
  },
  status: {
    type: String,
    required: true,
  },
});
</script>

<template>
  <div>{{ props.title }} - {{ props.status }}</div>
</template>

<style scoped>

</style>
