<script setup>

</script>

<template>
  <div class="modal-mask">
    <div class="modal-wrapper">
      <div class="modal-container">
        <p>Модальное окно</p>
        <button class="modal-default-button" @click="$emit('close')">
          OK
        </button>
      </div>
    </div>
  </div>
</template>

<style scoped>

</style>
