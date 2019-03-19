<template>
<body>
  <div class="adminaccount">
    <div class="container">
      <div class="columns">
        <div class="column is-3">
          <aside class="menu is-hidden-mobile">
            <p class="menu-label">General</p>
            <ul class="menu-list">
              <li>
                <a>Productions</a>
              </li>
              <li>
                <a>Reviews</a>
              </li>
            </ul>
            <p class="menu-label">Administration</p>
            <ul class="menu-list">
              <li>
                <a>Team Settings</a>
              </li>
              <li>
                <a>Manage Your Team</a>
                <ul>
                  <li>
                    <a>Members</a>
                  </li>
                  <li>
                    <a>Add a member</a>
                  </li>
                </ul>
              </li>
            </ul>
            <p class="menu-label">Help Wanted</p>
            <ul class="menu-list">
              <li>
                <a>Job Postings</a>
              </li>
            </ul>
            <p class="menu-label">Transactions</p>
            <ul class="menu-list">
              <li>
                <a>Payments</a>
              </li>
              <li>
                <a>Transfers</a>
              </li>
              <li>
                <a>Balance</a>
              </li>
            </ul>
          </aside>
        </div>
        <div class="column is-9">
          <section class="hero is-info welcome is-small">
            <div class="hero-body">
              <div class="container">
                <h1 class="title">Hello, Admin.</h1>
                <h2 class="subtitle">I hope you are having a great day!</h2>
              </div>
            </div>
          </section>
          <section class="info-tiles">
            <div class="tile is-ancestor has-text-centered">
              <div class="tile is-parent">
                <article class="tile is-child box">
                  <p class="title">43</p>
                  <p class="subtitle">Theater Members</p>
                </article>
              </div>
              <div class="tile is-parent">
                <article class="tile is-child box">
                  <p class="title">59</p>
                  <p class="subtitle">Productions</p>
                </article>
              </div>
              <div class="tile is-parent">
                <article class="tile is-child box">
                  <p class="title">3</p>
                  <p class="subtitle">Shows Selling</p>
                </article>
              </div>
              <div class="tile is-parent">
                <article class="tile is-child box">
                  <p class="title">19</p>
                  <p class="subtitle">Applications</p>
                </article>
              </div>
            </div>
          </section>
          <div class="columns">
            <div class="column is-6">
              <div class="card events-card">
                <header class="card-header">
                  <p class="card-header-title">Ticket Selling</p>
                  <a href="#" class="card-header-icon" aria-label="more options">
                    <span class="icon">
                      <i class="fa fa-angle-down" aria-hidden="true"></i>
                    </span>
                  </a>
                </header>
                <div class="card-table">
                  <div class="content">
                    <table class="table is-fullwidth is-striped">
                      <tbody>
                        <tr>
                          <td width="5%">
                            <i class="fa fa-bell-o"></i>
                          </td>
                          <td>Lorum ipsum dolem aire</td>
                          <td>
                            <a class="button is-small is-primary" href="#">Edit</a>
                          </td>
                        </tr>
                        <tr>
                          <td width="5%">
                            <i class="fa fa-bell-o"></i>
                          </td>
                          <td>Lorum ipsum dolem aire</td>
                          <td>
                            <a class="button is-small is-primary" href="#">Edit</a>
                          </td>
                        </tr>
                        <tr>
                          <td width="5%">
                            <i class="fa fa-bell-o"></i>
                          </td>
                          <td>Lorum ipsum dolem aire</td>
                          <td>
                            <a class="button is-small is-primary" href="#">Edit</a>
                          </td>
                        </tr>
                        <tr>
                          <td width="5%">
                            <i class="fa fa-bell-o"></i>
                          </td>
                          <td>Lorum ipsum dolem aire</td>
                          <td>
                            <a class="button is-small is-primary" href="#">Edit</a>
                          </td>
                        </tr>
                        <tr>
                          <td width="5%">
                            <i class="fa fa-bell-o"></i>
                          </td>
                          <td>Lorum ipsum dolem aire</td>
                          <td>
                            <a class="button is-small is-primary" href="#">Edit</a>
                          </td>
                        </tr>
                        <tr>
                          <td width="5%">
                            <i class="fa fa-bell-o"></i>
                          </td>
                          <td>Lorum ipsum dolem aire</td>
                          <td>
                            <a class="button is-small is-primary" href="#">Edit</a>
                          </td>
                        </tr>
                        <tr>
                          <td width="5%">
                            <i class="fa fa-bell-o"></i>
                          </td>
                          <td>Lorum ipsum dolem aire</td>
                          <td>
                            <a class="button is-small is-primary" href="#">Edit</a>
                          </td>
                        </tr>
                        <tr>
                          <td width="5%">
                            <i class="fa fa-bell-o"></i>
                          </td>
                          <td>Lorum ipsum dolem aire</td>
                          <td>
                            <a class="button is-small is-primary" href="#">Edit</a>
                          </td>
                        </tr>
                        <tr>
                          <td width="5%">
                            <i class="fa fa-bell-o"></i>
                          </td>
                          <td>Lorum ipsum dolem aire</td>
                          <td>
                            <a class="button is-small is-primary" href="#">Edit</a>
                          </td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>
                <footer class="card-footer">
                  <a href="#" class="card-footer-item">View All</a>
                </footer>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</body>
</template>

<script>
export default {
  name: "AdminAccount",
  data() {
    return {};
  },
  mounted() {},
  methods: {}
};
</script>
