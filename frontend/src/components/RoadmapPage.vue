<script setup>

import CRMainAndSecondaryNodes from "@/components/UI/CRMainAndSecondaryNodes.vue";
import {useHelpModalStore} from "@/stores/helpModal";

const helpModal = useHelpModalStore();

fetch("http://localhost:8081/Routes/2").then((result) => {
  console.log(result);
}).catch((error) => {
  console.log(error);
});

const nodes = [
  {
    id: 1,
    title: "Интернет",
    statusId: 4,
    secondaryNodes: [
      {
        id: 2, title: "Как работает интернет?",
        statusId: 4,
      }, {
        id: 3,
        title: "Что такое HTTP?",
        statusId: 4,
      },
    ],
  },
  {
    id: 4,
    title: "HTML",
    statusId: 3,
    secondaryNodes: [
      {
        id: 5, title: "Основы",
        statusId: 3,
      }, {
        id: 6,
        title: "Семантическая вёрстка",
        statusId: 3,
      },
    ],
  },
  {
    id: 7,
    title: "CSS",
    statusId: 2,
    secondaryNodes: [
      {
        id: 8, title: "Основы",
        statusId: 2,
      },
      {
        id: 9,
        title: "Создание макетов",
        statusId: 1,
      },
      {
        id: 10,
        title: "Отзывчивый дизайн",
        statusId: 1,
      },
    ],
  },
  {
    id: 11,
    title: "JavaScript",
    statusId: 1,
    secondaryNodes: [
      {
        id: 12, title: "Основы",
        statusId: 1,
      },
      {
        id: 13,
        title: " DOM",
        statusId: 1,
      },
    ],
  },
  {
    id: 14,
    title: "Системы контроля версий",
    statusId: 1,
    secondaryNodes: [
      {
        id: 111,
        title: "Привет",
        statusId: 4,
      },
    ],
  },
  {
    id: 15,
    title: "Системы управления пакетами",
    statusId: 1,
    secondaryNodes: [],
  },
  {
    id: 16,
    title: "Выбор Framework",
    statusId: 1,
    secondaryNodes: [],
  },
  {
    id: 17,
    title: "Написание CSS",
    statusId: 1,
    secondaryNodes: [],
  },
  {
    id: 18,
    title: "Архитектура CSS",
    statusId: 1,
    secondaryNodes: [],
  },
];


</script>

<template>
  <main class="crMain flexibleY gapMedium">
    <header class="crHeader">
      <div class="flexibleY gapSmaller">
        <h2 class="fn-caption"><b>Frontend Разработчик</b></h2>
        <p>Специалист, отвечающий за создание пользовательского интерфейса сайта, приложения или ПО</p>
      </div>
    </header>

    <div class="crProgressHead flexible bg-secondary radRound">
      <div class="flexible grow gapXSmallest">
        <div class="crFormItem button noShrink completed radSmall filled hSmall">33% пройдено</div>
        <ul class="statList flexible">
          <li class="item">3 изучено</li>
          <li class="item">2 в процессе</li>
          <li class="item">3 пропущено</li>
          <li class="item">18 всего</li>
        </ul>
      </div>
      <div class="flexible noShrink gapXSmallest" @click="helpModal.openHelpModal">
        <div class="crIcon bg-accent" style="--crMsk: url('/icons/question.svg');"></div>
        <div>Отслеживание прогресса</div>
      </div>
    </div>


    <div class="crTree">

      <CRMainAndSecondaryNodes
          v-for="(node, index) in nodes"
          v-bind:key="node.id"
          :id="node.id"
          :title="node.title"
          :index-in-array="index"
          :secondary-nodes="node.secondaryNodes"
          :status-id="node.statusId">
      </CRMainAndSecondaryNodes>

    </div>

  </main>
</template>

