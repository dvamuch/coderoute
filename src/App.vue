<template>
  <div class="uApiWrap">
    <HeaderComponent></HeaderComponent>

    <router-view></router-view>

    <FooterComponent></FooterComponent>

    <CRModalGroup></CRModalGroup>
  </div>
</template>

<script>
import FooterComponent from "@/components/UI/CRFooter.vue";
import HeaderComponent from "@/components/UI/CRHeader.vue";
import CRModalGroup from "@/components/UI/CRModalGroup.vue";
import {defineComponent} from "vue";

export default defineComponent({
  components: {CRModalGroup, FooterComponent, HeaderComponent},
});
</script>

