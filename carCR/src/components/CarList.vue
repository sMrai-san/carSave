<template>
    <div>
        <b-container>
            <b-row class="mb-3">
                <b-col class="float-start"><h4>Tietokannassa olevat ajoneuvot</h4></b-col>
                <b-col><b-button v-b-modal.carSaveModal variant="primary" class="float-end">Lisää ajoneuvo</b-button></b-col>
            </b-row>
            <b-table id="carTable"
                     hover
                     :items="carsFromDb"
                     :fields="fields"
                     thead-class="bg-light"
                     selectable
                     select-mode="single"
                     @row-clicked="deleteCar">

            </b-table>
        </b-container>
        <b-modal id="carSaveModal" size="xl" hide-footer title="Ajoneuvon lisäys tietokantaan">
            <CarSave />
        </b-modal>
    </div>
</template>

<script>
    import axios from 'axios'
    import CarSave from './CarSave.vue'

    export default {
        name: 'CarList',
        components: {
            CarSave
        },
        data() {
            return {
                //HOX! id field is hidden from the user
                fields: [
                    {
                        key: 'carMake',
                        label: 'Valmistaja',
                        sortable: true
                    },
                    {
                        key: 'carModel',
                        label: 'Malli',
                        sortable: true
                    },
                    {
                        key: 'carDate',
                        label: 'Vuosimalli',
                        sortable: true,
                    }
                ],
                carsFromDb: [],
                errorMsg: "",
            }
        },
        mounted() {
            this.loadCars();
            this.$root.$on('CarListHideAndRefresh', () => {
                this.$bvModal.hide('carSaveModal');
                window.location.reload(); //not so good way to refresh things, help wanted :)
            });
        },
        methods: {
            //Getting all the cars in the DB to list array
            loadCars() {
                axios.get('https://localhost:7280/api/CarData')
                    .then((response) => {
                        //console.log(response.data)
                        this.carsFromDb = response.data; //populatin cars 'array'
                    })
                    .catch((error) => {
                        //console.log(error)
                        this.errorMsg = 'Error retrieving data' + error;
                    })
            },
            deleteCar(row) {
                //fast confirmation car delete
                if (confirm('Haluatko varmasti poistaa ajoneuvon:\n' + 'AjoneuvoId: ' + row.carId + '\nMerkki:' + row.carMake + '\nMalli:' + row.carModel + '?')) {
                    axios.delete('https://localhost:7280/api/CarData/' + row.carId)
                        .then(response => console.log(response))
                        .catch(error => console.log(error))
                    //filter the carlist to 'refresh' the list after delete
                    this.carsFromDb = this.carsFromDb.filter(c => c.carId != row.carId);
                }
            },
        },
    }
</script>

<style scoped>
    /*Hiding the default sorting values*/
    ::v-deep .sr-only {
        display: none !important
    }
</style>