<script setup>

// import {computed, ref} from "vue";
// import {useRoute} from "vue-router";
// import {useAppStore} from "@/stores/app";

// const appStore = useAppStore();
// const showModal = computed(() => appStore.showModal);
// const route = useRoute();


import CRMainAndSecondaryNodes from "@/components/UI/CRMainAndSecondaryNodes.vue";

const nodes = [
  {
    id: 1,
    title: "Интернет",
    status: "finished",
    secondaryNodes: [
      {
        id: 2, title: "Как работает интернет?", status: "finished",
      }, {
        id: 3,
        title: "Что такое HTTP?",
        status: "finished",
      },
    ],
  },
  {
    id: 4,
    title: "HTML",
    status: "skipped",
    secondaryNodes: [
      {
        id: 5, title: "Основы", status: "finished",
      }, {
        id: 6,
        title: "Семантическая вёрстка",
        status: "finished",
      },
    ],
  },
  {
    id: 7,
    title: "CSS",
    status: "skipped",
    secondaryNodes: [
      {
        id: 8, title: "Основы", status: "finished",
      },
      {
        id: 9,
        title: "Создание макетов",
        status: "finished",
      },
      {
        id: 10,
        title: "Отзывчивый дизайн",
        status: "finished",
      },
    ],
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
      <a title="" href="#" class="flexible noShrink gapXSmallest">
        <div class="crIcon bg-accent" style="--crMsk: url('/icons/question.svg');"></div>
        <div>Отслеживание прогресса</div>
      </a>
    </div>


    <div class="crTree">

      <CRMainAndSecondaryNodes
          v-for="(node, index) in nodes"
          v-bind:key="node.id"
          :id="node.id"
          :title="node.title"
          :index-in-array="index"
          :secondary-nodes="node.secondaryNodes"
          :status="node.status">
      </CRMainAndSecondaryNodes>

      <!--      <div class="vLine bg-secondary2"></div>-->

      <!--      <div class="treeBlock">-->

      <!--        <div class="section side left">-->
      <!--          <div class="sideIn">-->

      <!--            <div class="buttons">-->
      <!--              <div class="crFormItem button noShrink secondary2 radMedium filled hMedium">Основы</div>-->
      <!--              <div class="crFormItem button noShrink secondary2 radMedium filled hMedium">Семантическая верстка</div>-->
      <!--            </div>-->

      <!--            <div class="lines">-->
      <!--              <div class="curve fn-secondary2">-->
      <!--                <svg viewBox="0 0 400 400" preserveAspectRatio="none">-->
      <!--                  <path class="path" d="M 0 400 C 0 300 200 0 400 0"/>-->
      <!--                  <path class="path" d="M 0 200 C 100 -200 300 -200 400 200"/>-->
      <!--                  <path class="path" d="M 0 0 C 100 0 300 100 400 400"/>-->
      <!--                </svg>-->
      <!--              </div>-->
      <!--              <div class="curve fn-secondary2">-->
      <!--                <svg viewBox="0 0 400 400" preserveAspectRatio="none">-->
      <!--                  <path class="path" d="M 0 400 C 0 300 200 0 400 0"/>-->
      <!--                  <path class="path" d="M 0 200 C 100 -200 300 -200 400 200"/>-->
      <!--                  <path class="path" d="M 0 0 C 100 0 300 100 400 400"/>-->
      <!--                </svg>-->
      <!--              </div>-->
      <!--            </div>-->

      <!--          </div>-->
      <!--        </div>-->

      <!--        <div class="section">-->

      <!--          <div class="crFormItem button noShrink secondary2 radSmall filled hMedium">HTML</div>-->

      <!--        </div>-->

      <!--        <div class="section side right"></div>-->

      <!--      </div>-->
      <!--      <div class="vLine bg-primary"></div>-->
      <!--      <div class="treeBlock">-->

      <!--        <div class="section side left"></div>-->

      <!--        <div class="section">-->

      <!--          <div class="crFormItem button noShrink primary radSmall filled hMedium">CSS</div>-->

      <!--        </div>-->

      <!--        <div class="section side right">-->
      <!--          <div class="sideIn">-->

      <!--            <div class="lines">-->
      <!--              <div class="curve fn-primary">-->
      <!--                <svg viewBox="0 0 400 400" preserveAspectRatio="none">-->
      <!--                  <path class="path" d="M 0 400 C 0 300 200 0 400 0"/>-->
      <!--                  <path class="path" d="M 0 200 C 100 -200 300 -200 400 200"/>-->
      <!--                  <path class="path" d="M 0 0 C 100 0 300 100 400 400"/>-->
      <!--                </svg>-->
      <!--              </div>-->
      <!--              <div class="curve fn-primary">-->
      <!--                <svg viewBox="0 0 400 400" preserveAspectRatio="none">-->
      <!--                  <path class="path" d="M 0 400 C 0 300 200 0 400 0"/>-->
      <!--                  <path class="path" d="M 0 200 C 100 -200 300 -200 400 200"/>-->
      <!--                  <path class="path" d="M 0 0 C 100 0 300 100 400 400"/>-->
      <!--                </svg>-->
      <!--              </div>-->
      <!--              <div class="curve fn-primary">-->
      <!--                <svg viewBox="0 0 400 400" preserveAspectRatio="none">-->
      <!--                  <path class="path" d="M 0 400 C 0 300 200 0 400 0"/>-->
      <!--                  <path class="path" d="M 0 200 C 100 -200 300 -200 400 200"/>-->
      <!--                  <path class="path" d="M 0 0 C 100 0 300 100 400 400"/>-->
      <!--                </svg>-->
      <!--              </div>-->
      <!--            </div>-->

      <!--            <div class="buttons">-->
      <!--              <div class="crFormItem button noShrink primary radMedium filled hMedium">Основы</div>-->
      <!--              <div class="crFormItem button noShrink primary radMedium hMedium">Создание макетов</div>-->
      <!--              <div class="crFormItem button noShrink primary radMedium hMedium">Отзывчивый дизайн</div>-->
      <!--            </div>-->

      <!--          </div>-->
      <!--        </div>-->

      <!--      </div>-->
      <!--      <div class="vLine bg-primary"></div>-->
      <!--      <div class="treeBlock">-->

      <!--        <div class="section side left">-->
      <!--          <div class="sideIn">-->

      <!--            <div class="buttons">-->
      <!--              <div class="crFormItem button noShrink primary radMedium hMedium">Основы</div>-->
      <!--              <div class="crFormItem button noShrink primary radMedium hMedium">DOM</div>-->
      <!--            </div>-->

      <!--            <div class="lines">-->
      <!--              <div class="curve fn-primary">-->
      <!--                <svg viewBox="0 0 400 400" preserveAspectRatio="none">-->
      <!--                  <path class="path" d="M 0 400 C 0 300 200 0 400 0"/>-->
      <!--                  <path class="path" d="M 0 200 C 100 -200 300 -200 400 200"/>-->
      <!--                  <path class="path" d="M 0 0 C 100 0 300 100 400 400"/>-->
      <!--                </svg>-->
      <!--              </div>-->
      <!--              <div class="curve fn-primary">-->
      <!--                <svg viewBox="0 0 400 400" preserveAspectRatio="none">-->
      <!--                  <path class="path" d="M 0 400 C 0 300 200 0 400 0"/>-->
      <!--                  <path class="path" d="M 0 200 C 100 -200 300 -200 400 200"/>-->
      <!--                  <path class="path" d="M 0 0 C 100 0 300 100 400 400"/>-->
      <!--                </svg>-->
      <!--              </div>-->
      <!--            </div>-->

      <!--          </div>-->
      <!--        </div>-->

      <!--        <div class="section">-->

      <!--          <div class="crFormItem button noShrink primary radSmall hMedium">JavaScript</div>-->

      <!--        </div>-->

      <!--        <div class="section side right"></div>-->

      <!--      </div>-->
      <!--      <div class="vLine bg-primary"></div>-->
      <!--      <div class="treeBlock">-->

      <!--        <div class="section side left"></div>-->

      <!--        <div class="section">-->

      <!--          <div class="crFormItem button noShrink primary radSmall hMedium">Системы контроля версий</div>-->

      <!--        </div>-->

      <!--        <div class="section side right"></div>-->

      <!--      </div>-->
      <!--      <div class="vLine bg-primary"></div>-->
      <!--      <div class="treeBlock">-->

      <!--        <div class="section side left"></div>-->

      <!--        <div class="section">-->

      <!--          <div class="crFormItem button noShrink primary radSmall hMedium">Выбор Framework</div>-->

      <!--        </div>-->

      <!--        <div class="section side right"></div>-->

      <!--      </div>-->
      <!--      <div class="vLine bg-primary"></div>-->
      <!--      <div class="treeBlock">-->

      <!--        <div class="section side left"></div>-->

      <!--        <div class="section">-->

      <!--          <div class="crFormItem button noShrink primary radSmall hMedium">Написание CSS</div>-->

      <!--        </div>-->

      <!--        <div class="section side right"></div>-->

      <!--      </div>-->
      <!--      <div class="vLine bg-primary"></div>-->
      <!--      <div class="treeBlock">-->

      <!--        <div class="section side left"></div>-->

      <!--        <div class="section">-->

      <!--          <div class="crFormItem button noShrink primary radSmall hMedium">Архитектура CSS</div>-->

      <!--        </div>-->

      <!--        <div class="section side right"></div>-->

      <!--      </div>-->


      <!--
      <div class="treeBlock">

          <div class="section side left">
              <div class="sideIn">

                  <div class="buttons">
                      <div class="crFormItem button noShrink primary radSmall filled hMedium">Самый длинный подпункт</div>
                      <div class="crFormItem button noShrink completed radSmall filled hMedium">Длинный подпункт</div>
                      <div class="crFormItem button noShrink secondary2 radSmall filled hMedium">Подпункт</div>
                  </div>

                  <div class="lines">
                      <div class="curve fn-completed">
                          <svg viewBox="0 0 400 400" preserveAspectRatio="none">
                              <path class="path" d="M 0 400 C 0 300 200 0 400 0"/>
                          </svg>
                      </div>
                      <div class="curve fn-completed">
                          <svg viewBox="0 0 400 400" preserveAspectRatio="none">
                              <path class="path" d="M 0 200 C 100 -200 300 -200 400 200"/>
                          </svg>
                      </div>
                      <div class="curve fn-completed">
                          <svg viewBox="0 0 400 400" preserveAspectRatio="none">
                              <path class="path" d="M 0 0 C 100 0 300 100 400 400"/>
                          </svg>
                      </div>
                  </div>

              </div>
          </div>

          <div class="section">

              <div class="crFormItem button noShrink secondary2 radSmall filled hMedium">HTML</div>

          </div>

          <div class="section side right">
              <div class="sideIn">

                  <div class="lines">
                      <div class="curve fn-completed">
                          <svg viewBox="0 0 400 400" preserveAspectRatio="none">
                              <path class="path" d="M 0 400 C 0 300 200 0 400 0"/>
                          </svg>
                      </div>
                      <div class="curve fn-completed">
                          <svg viewBox="0 0 400 400" preserveAspectRatio="none">
                              <path class="path" d="M 0 200 C 100 -200 300 -200 400 200"/>
                          </svg>
                      </div>
                      <div class="curve fn-completed">
                          <svg viewBox="0 0 400 400" preserveAspectRatio="none">
                              <path class="path" d="M 0 0 C 100 0 300 100 400 400"/>
                          </svg>
                      </div>
                  </div>

                  <div class="buttons">
                      <div class="crFormItem button noShrink primary radSmall filled hMedium">Основы</div>
                      <div class="crFormItem button noShrink completed radSmall filled hMedium">Длинный подпункт</div>
                      <div class="crFormItem button noShrink secondary2 radSmall filled hMedium">Семантическая верстка</div>
                  </div>

              </div>
          </div>

      </div>
      -->

    </div>

  </main>
</template>

