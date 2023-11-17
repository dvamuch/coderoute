<script setup>

defineProps({
  closeAction: {
    type: Function,
    required: true,
  },
});

</script>

<template>
  <div class="crModalWrap scrollHide">
    <div class="absFill modalToggle"></div>
    <div class="crModalWindow" v-click-out="closeAction">

      <slot>
        <p>Ты пидор!</p>
      </slot>

      <div class="crModalClose modalToggle" title="Закрыть" @click="closeAction">
        <div class="crIcon sSmall " style="--crMsk: url('/icons/close.svg');"></div>
      </div>
    </div>
  </div>

</template>
