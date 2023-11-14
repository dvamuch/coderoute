<script setup>

import FooterMenuComponent from "@/components/UI/CRFooterMenu.vue";
import LogoComponent from "@/components/UI/CRLogo.vue";
</script>

<template>
  <footer class="crFooter">
    <div class="leftSide flexibleY gapSmallest">
      <router-link class="flexible gapSmallest" to="/">
        <LogoComponent></LogoComponent>
        <span>Code<span class="fn-primary">Route</span></span>
      </router-link>
      <p>© 2023 CodeRoute. Все права защищены </p>
    </div>
    <div class="rightSide flexible">
      <FooterMenuComponent title="О продукте" :menu-items="['Новости', 'Команда']"></FooterMenuComponent>
      <FooterMenuComponent title="Давайте общаться" :menu-items="['Наши контакты', 'GitHub']"></FooterMenuComponent>
      <!--      <ul class="rightList flexibleY">-->
      <!--        <li><h3 class="listItem title">О продукте</h3></li>-->
      <!--        <li><a href="#" class="listItem">Новости</a></li>-->
      <!--        <li><a href="#" class="listItem">Команда</a></li>-->
      <!--      </ul>-->
      <!--      <ul class="rightList flexibleY">-->
      <!--        <li><h3 class="listItem title">Давайте общаться</h3></li>-->
      <!--        <li><a href="#" class="listItem">Наши контакты</a></li>-->
      <!--        <li><a href="#" class="listItem">GitHub</a></li>-->
      <!--      </ul>-->
    </div>
  </footer>


</template>
