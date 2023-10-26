<template>
  <HeaderComponent></HeaderComponent>
  <router-view></router-view>

  <FooterComponent></FooterComponent>
</template>

<script>
import FooterComponent from "@/components/UI/FooterComponent.vue";
import HeaderComponent from "@/components/UI/HeaderComponent.vue";
import {defineComponent} from "vue";

export default defineComponent({
  components: {FooterComponent, HeaderComponent},
});
</script>

<style>

</style>
