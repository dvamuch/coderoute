<script setup>

import CRLogo from "@/components/UI/CRLogo.vue";
</script>

<template>
  <!--  <CRModal v-if="showModal" @close="showModal = false"></CRModal>-->

  <h1 class="hide">CodeRoute</h1>

  <nav class="crMainNav gapMedium">
    <div class="flexible gapMedium">
      <router-link class="noShrink" to="/">
        <CRLogo></CRLogo>
      </router-link>
      <router-link to="/roadmaps" class="crFormItem button hMedium transparent nopad">Дорожные карты</router-link>
    </div>

    <ul class="flexible">
      <li class="crFormItem button hMedium transparent">
        <a class="flexible gapXSmallest">
          <div>hiikari</div>
          <div class="crMiniAvatar sSmall">
            <img class="img avatar" alt="" src="@/assets/avatar.png"/>
          </div>
        </a>
      </li>
    </ul>
  </nav>
</template>
