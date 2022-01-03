<template>
    <div id="app">
        <div class="logo-container carSaveLogo">
            <ul>
                <li>
                    <div class="logo">
                        <a href="#">
                            <h3>Ajoneuvo</h3>
                            <p>tietovarasto</p>
                        </a>
                    </div>
                </li>
            </ul>
        </div>
        <CarList />
    </div>
</template>

<script>
    import CarList from './components/CarList.vue'

    export default {
        name: 'App',
        components: {
            CarList
        },
    }
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        color: #2c3e50;
        margin-top: 46px;
    }

    .carSaveLogo {
        text-align: center;
    }
    /*https://codepen.io/maheshambure21/pen/MWWgyyG*/
    /* Logo */
    .logo h3 {
        color: #e74c3c;
        font-family: 'Oswald', sans-serif;
        font-weight: 300;
        font-size: 50px;
        text-transform: uppercase;
        line-height: 1;
    }

    .logo p {
        font-size: 14px;
        padding-left: 0px;
        color: #34495e;
        font-weight: 600;
        text-transform: uppercase;
    }

    .logo-container ul {
        margin: 0 0 20px 0;
        padding: 0;
        list-style: none;
        display: inline-block;
    }

        .logo-container ul li {
            width: 300px;
            height: 120px;
            background: #fff;
            border-radius: 10px;
            padding: 20px;
            box-shadow: 0px 5px 10px rgba(0, 0, 0, 0.25);
            display: flex;
            align-items: center;
            justify-content: center;
        }

            .logo-container ul li a {
                text-decoration: none !important;
                display: inline-block;
            }

    .logo-holder {
        text-align: center;
    }
</style>
