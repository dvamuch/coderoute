<template>
  <div class="uApiWrap">
    <HeaderComponent></HeaderComponent>
    <router-view></router-view>

    <FooterComponent></FooterComponent>
  </div>
</template>

<script>
import FooterComponent from "@/components/UI/CRFooter.vue";
import HeaderComponent from "@/components/UI/CRHeader.vue";
import {defineComponent} from "vue";

export default defineComponent({
  components: {FooterComponent, HeaderComponent},
});
</script>

<style>

</style>
