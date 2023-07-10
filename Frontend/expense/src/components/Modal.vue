<template>
    <transition name="fade" appear>
      <div class="vue-modal" v-show="localIsModalOpen">
        <transition name="pop" appear>
          <div class="vue-modal-inner">
            <transition name="fade">
              <div class="vue-modal-content">
                <div class="modal-header" col-mb-2>
                  <h2 class="modal-title">{{ModalHeader}}</h2>
                </div>
                <div class="modal-body">
                  <!-- modal content -->
                  <slot />
                </div>
                <div class="modal-footer">
                  <button type="button" class="btn btn-outline-secondary" @click="closeModal">Close</button>
                </div>
              </div>
            </transition>
          </div>
        </transition>
      </div>
    </transition>
  </template>
  
  <script setup>
  import { ref, watchEffect, getCurrentInstance  } from 'vue';
  
  const props = defineProps({
    isModalOpen: {
      type: Boolean,
      required: true,
    },
    ModalHeader:{
      type: String,
      required: true,
    },
  });
  
  const localIsModalOpen = ref(props.isModalOpen);
  
  watchEffect(() => {
    localIsModalOpen.value = props.isModalOpen;
  });
  
  
  const instance = getCurrentInstance();
  
  const closeModal = () => {
    instance.emit('close');
  };
  </script>
    
  <style scoped>
  .modal-title {
    text-align: center;
    height: 100%;
    margin: 0;
    padding: 0;
    display: flex;
  }
    .vue-modal {
      position: fixed;
      top: 0;
      left: 0;
      width:100%;
      height: 100%;
      background-color: rgba(0, 0, 0, 0.4);
      z-index: 1;
      transition: opacity 0.5s;
    }
  
    .vue-modal-inner {
      max-width: 30%;
      margin: 2rem auto;
    }
  
    .vue-modal-content {
      position: relative;
      top: 10em;
      background-color: #fff;
      border: 2px solid rgba(0, 0, 0, 0.3);
      background-clip: padding-box;
      border-radius: 1rem;
      padding: 1rem;
    }
  /* animation */
  .fade-enter-active,
  .fade-leave-active {
    transition: opacity .4s linear;
  }
  
  .fade-enter,
  .fade-leave-to {
    opacity: 0;
  }
  
  .pop-enter-active,
  .pop-leave-active {
    transition: transform 0.4s cubic-bezier(0.5, 0, 0.5, 1), opacity 0.4s linear;
  }
  
  .pop-enter,
  .pop-leave-to {
    opacity: 0;
    transform: scale(0.3) translateY(-50%);
  }
    
  </style>