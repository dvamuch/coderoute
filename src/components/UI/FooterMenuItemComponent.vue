<script setup>
const props = defineProps({
  text: {
    type: String,
    required: true,
  },
});
</script>

<template>

  <div>{{ props.text}}</div>

</template>

<style scoped>

</style>
