import {defineStore} from "pinia";

const statusIdToNodeClasses = {
  1: { // new
    primary: true,
  },
  2: { // in_progress
    filled: true,
    primary: true,
  },
  3: { // skipped
    filled: true,
    secondary2: true,
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
  2: { // in_progress
    "fn-primary": true,
  },
  3: { // skipped
    "fn-secondary2": true,
  },
  4: { // done
    "fn-completed": true,
  },
};

const statusIdToVerticalLineClasses = {
  1: { // new
    "bg-accent": true,
  },
  2: { // in_progress
    "bg-primary": true,
  },
  3: { // skipped
    "bg-secondary2": true,
  },
  4: { // done
    "bg-completed": true,
  },
};

export const useNodeStatusStore = defineStore("nodeStatus", () => {

  const getNodeClassesByStatusId = (statusId) => {
    return statusIdToNodeClasses[statusId];
  };

  const getLineClassesByStatusId = (statusId) => {
    return statusIdToLineClasses[statusId];
  };

  const getVerticalLineClassesByStatusId = (statusId) => {
    return statusIdToVerticalLineClasses[statusId];
  };

  return {getNodeClassesByStatusId, getLineClassesByStatusId, getVerticalLineClassesByStatusId};
});
