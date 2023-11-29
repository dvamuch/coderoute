<script setup>

const props = defineProps({
  nodeId: {
    type: Number,
    required: true,
  },
});

import {useNodesStore} from "@/stores/nodes";
import {computed, onMounted} from "vue";

const nodesStore = useNodesStore();

const nodeObject = computed(() => nodesStore.nodeObjects[props.nodeId]);

onMounted(async () => {
  await nodesStore.fetchNode(props.nodeId);
});


</script>

<template>

  <div class="flexibleY gapMedium">
    <div class="flexibleY gapXSmallest">


      <div class="flexible">

        <div class="crSelect flexible">
          <div class="crFormItem crSelectInput button noShrink secondary radSmall hSmall gapMini">
            <div class="sSmallest crFormItem radRound completed filled"></div>
            <div class="grow">Изучил</div>
          </div>
          <div class="crFormItem crSelectButton button noShrink primary filled radSmall hSmall gapMini">
            <div>Обновить статус</div>
            <div class="crSelectArrow">df</div>
          </div>

          <div class="crSelectContent bg-background">
            <ul class="borderedList">
              <li class="item flexible gapMini link">
                <div class="sSmallest crFormItem radRound secondary2 filled"></div>
                <div>Пропустил</div>
              </li>
              <li class="item flexible gapMini link">
                <div class="sSmallest crFormItem radRound primary"></div>
                <div>Не изучаю</div>
              </li>
              <li class="item flexible gapMini link">
                <div class="sSmallest crFormItem radRound primary filled"></div>
                <div>В процессе</div>
              </li>
              <li class="item flexible gapMini link">
                <div class="sSmallest crFormItem radRound completed filled"></div>
                <div>Изучил</div>
              </li>
            </ul>
          </div>
        </div>

      </div>


      <h6 class="fn-subcap"><b>{{ nodeObject }} {{ props.nodeId }}</b></h6>
      <p class="lhMain">Интернет — это глобальная сеть, которая объединяет огромное количество компьютеров по всему
        земному шару и дает возможность получения доступа к информационным ресурсам.</p>
      <p class="lhMain">Чтобы узнать больше, изучите следующие материалы:</p>
      <ul class="linkedList fn-accent">
        <li class="item">
          <a title="" href="#" class="link">Как работает интернет?</a>
        </li>
        <li class="item">
          <a title="" href="#" class="link">Интернет в деталях</a>
        </li>
        <li class="item">
          <a title="" href="#" class="link">Введение в интернет</a>
        </li>
        <li class="item">
          <a title="" href="#" class="link">Как работает Web?</a>
        </li>
      </ul>
    </div>

  </div>

</template>
