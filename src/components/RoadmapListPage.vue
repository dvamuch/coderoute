<script setup>

import CRRoadmapListGroup from "@/components/UI/CRRoadmapListGroup.vue";

const developerRoadmapList = [
  {
    roadmapId: 1,
    progress: 33,
    isStarted: true,
    title: "Frontend Разработчик",
    description: "Специалист, отвечающий за создание пользовательского интерфейса сайта, приложения или ПО",
  },
  {
    roadmapId: 1,
    progress: 0,
    isStarted: false,
    title: "Frontend Разработчик",
    description: "Специалист, отвечающий за создание пользовательского интерфейса сайта, приложения или ПО",
  },
  {
    roadmapId: 1,
    progress: 0,
    isStarted: false,
    title: "Frontend Разработчик",
    description: "Специалист, отвечающий за создание пользовательского интерфейса сайта, приложения или ПО",
  },
  {
    roadmapId: 1,
    progress: 33,
    isStarted: true,
    title: "Frontend Разработчик",
    description: "Специалист, отвечающий за создание пользовательского интерфейса сайта, приложения или ПО",
  },
];
</script>

<template>
  <main class="crMain flexibleY gapMedium">
    <header class="crHeader">
      <div class="flexibleY gapSmaller">
        <h2 class="fn-caption"><b>Дорожные карты</b></h2>
      </div>
    </header>

    <CRRoadmapListGroup :roadmap-list="developerRoadmapList" profession-name="Разработка"></CRRoadmapListGroup>



    <section class="flexibleY gapSmall wmxAltContent">
      <h3 class="fn-subcap"><b>Разработка</b></h3>
      <ul class="crCards x2 gapSmaller">
        <li class="crCard flexibleY stretch gapXSmallest">
          <h4 class="fn-adv"><b>Frontend Разработчик</b></h4>
          <p class="lhMain">Специалист, отвечающий за создание пользовательского интерфейса</p>
          <div class="flexible flex-bottom">
            <div class="fn-completed grow">33% пройдено</div>
            <a title="" href="#" class="crFormItem button noShrink primary radRound filled hMedium">Продолжить</a>
          </div>
        </li>
        <li class="crCard flexibleY stretch gapXSmallest">
          <h4 class="fn-adv"><b>Ваша профессия</b></h4>
          <p class="lhMain">Здесь может быть рекомендованная вами профессия в разработке</p>
          <div class="flexible flex-bottom">
            <div class="fn-completed grow"></div>
            <a title="" href="#" class="crFormItem button noShrink accent radRound filled hMedium">Рекомендовать</a>
          </div>
        </li>
      </ul>
    </section>


    <section class="flexibleY gapSmall wmxAltContent">
      <h3 class="fn-subcap"><b>Аналитика</b></h3>
      <ul class="crCards x2 gapSmaller">
        <li class="crCard flexibleY stretch gapXSmallest">
          <h4 class="fn-adv"><b>Бизнес-аналитик</b></h4>
          <p class="lhMain">Специалист, изучающий и оптимизирующий бизнес-процессы</p>
          <div class="flexible flex-bottom">
            <div class="fn-completed grow"></div>
            <a title="" href="#" class="crFormItem button noShrink primary radRound filled hMedium">Ознакомиться</a>
          </div>
        </li>
        <li class="crCard flexibleY stretch gapXSmallest">
          <h4 class="fn-adv"><b>Ваша профессия</b></h4>
          <p class="lhMain">Здесь может быть рекомендованная вами профессия в разработке</p>
          <div class="flexible flex-bottom">
            <div class="fn-completed grow"></div>
            <a title="" href="#" class="crFormItem button noShrink accent radRound filled hMedium">Рекомендовать</a>
          </div>
        </li>
      </ul>
    </section>


    <section class="flexibleY gapSmall wmxAltContent">
      <h3 class="fn-subcap"><b>Дизайн</b></h3>
      <ul class="crCards x2 gapSmaller">
        <li class="crCard flexibleY stretch gapXSmallest">
          <h4 class="fn-adv"><b>UX-дизайнер</b></h4>
          <p class="lhMain">Специалист, проектирующий удобные для пользователей интерфейсы</p>
          <div class="flexible flex-bottom">
            <div class="fn-completed grow"></div>
            <a title="" href="#" class="crFormItem button noShrink primary radRound filled hMedium">Ознакомиться</a>
          </div>
        </li>
        <li class="crCard flexibleY stretch gapXSmallest">
          <h4 class="fn-adv"><b>Ваша профессия</b></h4>
          <p class="lhMain">Здесь может быть рекомендованная вами профессия в разработке</p>
          <div class="flexible flex-bottom">
            <div class="fn-completed grow"></div>
            <a title="" href="#" class="crFormItem button noShrink accent radRound filled hMedium">Рекомендовать</a>
          </div>
        </li>
      </ul>
    </section>

  </main>
</template>
