<style scoped>
    .button {
        background-color: #24305e;
        -moz-border-radius: 17px;
        -webkit-border-radius: 17px;
        border-radius: 17px;
        display: inline-block;
        cursor: pointer;
        color: #fff;
        font-family: Arial;
        font-size: 17px;
        font-weight: bold;
        padding: 5px 10px;
        text-decoration: none;
    }

        .button:hover {
            background-color: #4a7897;
        }

        .button:active {
            position: relative;
            top: 1px;
        }

    .mentor-card {
        border: 1px #efefef solid;
        -webkit-box-shadow: 1px 1px 1px -2px rgba(219, 219, 219, 1);
        -moz-box-shadow: 1px 1px 1px -2px rgba(219, 219, 219, 1);
        box-shadow: 1px 1px 1px -2px rgba(219, 219, 219, 1);
        transition-timing-function: ease-in;
        transition-property: box-shadow;
        transition-duration: .1s;
        transition-timing-function: linear;
        text-align: center;
        margin-bottom: 5px;
        margin-top: 5px;
        background-color: #fff;
        /* -webkit-text-fill-color: #fff; */
    }

    .card-img {
        position: relative;
        align-self: auto;
        width: 400px;
        height: 300px;
        background-position: 50% 50%;
        background-repeat: no-repeat;
        /* background-size: cover; */
        object-fit: cover;
    }

    .thumb {
        height: 20px;
        width: 20px;
        margin: 2px;
    }

    .round-card {
        border-radius: 4px;
        overflow: hidden;
        margin-bottom: 20px;
        /* max-height: 550px; */
    }

    .mentor-card:hover {
        -webkit-box-shadow: 5px 5px 5px -2px rgba(219, 219, 219, 1);
        -moz-box-shadow: 5px 5px 5px -2px rgba(219, 219, 219, 1);
        box-shadow: 5px 5px 5px -2px rgba(219, 219, 219, 1);
    }
</style>

<template>
    <div class="mentor-card" :class="{'round-card':rounded}">
        <img :src="mentor.imageUrl" class="card-img img-fluid">
        <div class="ml-3 font-weight-bold">
            <p class="name-color mt-3 mb-0" style="font-size: 22px">{{mentor.firstName}} {{mentor.lastName}}</p>
            <p class:="black-text m-0">{{mentor.position}}</p>
            <div class="badge badge-pill text-white badge-blue mr-2" v-for="skill in mentor.skillsList" :key="skill">{{skill}}</div><br>
            <a :href="'/home/mentoringrequests/'+mentor.id" class="button text-white mt-4">Request Help</a>
            <br>
            <img src="/images/thumbs-up-solid.png" class="thumb float-right ml-2 mr-4" @click="addLike()" />
            <p class="float-right">{{likeCount}}</p>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: 'MentorCard',
        data: () => ({
            likeCount: 0
        }),
        props: {
            mentor: {
                type: Object,
                default: () => { }
            },
            rounded: Boolean
            
        },
        mounted() {
            this.likeCount = this.mentor.rating;
        },
        methods: {
            async addLike() {
                const { data } = await axios.post('/api/Mentors/' + this.mentor.id + '/like');
                this.likeCount = data.rating;
            }
        }
    }

</script>