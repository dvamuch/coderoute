import {defineStore} from "pinia";

const statusIdToNodeClasses = {
  1: { // new
    primary: true,
  },
  2: { // skipped
    filled: true,
    secondary2: true,
  },
  3: { // in_progress
    filled: true,
    primary: true,
  },
  4: { // done
    filled: true,
    completed: true,
  },
};

const statusIdToLineClasses = {
  1: { // new
    "fn-accent": true,
  },
  2: { // skipped
    "fn-secondary2": true,
  },
  3: { // in_progress
    "fn-primary": true,
  },
  4: { // done
    "fn-completed": true,
  },
};

const statusIdToVerticalLineClasses = {
  1: { // new
    "bg-accent": true,
  },
  2: { // skipped
    "bg-secondary2": true,
  },
  3: { // in_progress
    "bg-primary": true,
  },
  4: { // done
    "bg-completed": true,
  },
};

const statusIdToName = {
  1: "Не изучаю",
  2: "Попустил",
  3: "В процессе",
  4: "Изучил",
};

export const useNodeStatusStore = defineStore("nodeStatus", () => {

  const getNodeClassesByStatusId = (statusId) => {
    console.log(statusIdToNodeClasses[statusId]);
    return statusIdToNodeClasses[statusId];
  };

  const getLineClassesByStatusId = (statusId) => {
    return statusIdToLineClasses[statusId];
  };

  const getVerticalLineClassesByStatusId = (statusId) => {
    return statusIdToVerticalLineClasses[statusId];
  };

  const getNameByStatusId = (statusId) => {
    return statusIdToName[statusId];
  };

  const getOtherStatuses = (statusId) => {
    
  };

  return {getNodeClassesByStatusId, getLineClassesByStatusId, getVerticalLineClassesByStatusId, getNameByStatusId};
});
