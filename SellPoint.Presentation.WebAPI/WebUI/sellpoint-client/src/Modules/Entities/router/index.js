export default {
  name: "entities",
  component: () =>
    import(/* webpackChunkName: "entities" */ "../layouts/EntityLayout.vue"),
  children: [
    {
      path: "Donaciones",
      name: "blood-donation-pages",
      component: () =>
        import(
          /* webpackChunkName: "entities-pages" */ "../views/BloodDonationsListPage.vue"
        ),
    },
    {
      path: "",
      name: "entities-pages",
      component: () =>
        import(
          /* webpackChunkName: "entities-pages" */ "../views/EntitiesListPages.vue"
        ),
    },
    {
      path: "Peticiones",
      name: "request-pages",
      component: () =>
        import(
          /* webpackChunkName: "entities-pages" */ "../views/RequestListPages.vue"
        ),
    },
    {
      path: "Create",
      name: "entities-create",
      component: import(
        /* webpackChunkName: "entities-create" */ "../views/EntitiesCreateOrEdit.vue"
      ),
    },
    {
      path: "Edit/:id",
      name: "entities-edit",
      component: import(
        /* webpackChunkName: "entities-edit" */ "../views/EntitiesCreateOrEdit.vue"
      ),
    },
    {
      path: "Show/:id",
      name: "blood-donation-show",
      component: import(
        /* webpackChunkName: "entities-create" */ "../views/BloodDonationsCreateOrEdit.vue"
      ),
    },
    {
      path: "Create",
      name: "blood-donation-create",
      component: import(
        /* webpackChunkName: "entities-create" */ "../views/BloodDonationsCreateOrEdit.vue"
      ),
    },
    {
      path: "Edit/:id",
      name: "blood-donation-edit",
      component: import(
        /* webpackChunkName: "entities-edit" */ "../views/BloodDonationsCreateOrEdit.vue"
      ),
    },
    {
      path: "Show/:id",
      name: "entities-show",
      component: import(
        /* webpackChunkName: "entities-create" */ "../views/EntitiesCreateOrEdit.vue"
      ),
    },
    {
      path: "Show/:id",
      name: "request-show",
      component: import(
        /* webpackChunkName: "entities-create" */ "../views/RequestCreateOrEdit.vue"
      ),
    },
    {
      path: "Create",
      name: "request-create",
      component: import(
        /* webpackChunkName: "entities-create" */ "../views/RequestCreateOrEdit.vue"
      ),
    },
    {
      path: "Edit/:id",
      name: "request-edit",
      component: import(
        /* webpackChunkName: "entities-edit" */ "../views/RequestCreateOrEdit.vue"
      ),
    },
  ],
};
