<template>
  <header>
    <h1 class="text-3xl">Dynamic Todo App</h1>
  </header>
  <main class="flex flex-1">
    <RouterView />
  </main>
</template> 
<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { RouterView } from 'vue-router'

</script>