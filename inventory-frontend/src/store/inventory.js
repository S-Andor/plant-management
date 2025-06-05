import { defineStore } from 'pinia';

export const useInventoryStore = defineStore('inventory', {
  state: () => ({
    items: [],
  }),
  actions: {
    setItems(data) {
      this.items = data;
    },
  },
});