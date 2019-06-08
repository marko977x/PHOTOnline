<template>
    <div class="profile-info-page">
        <user-profile-info 
            @openChangePasswordForm="openChangePasswordForm" />
        <el-dialog 
            title="Promena lozinke" center
            @close="closeChangePasswordForm" 
            :visible="isChangePasswordFormVisible" 
            :modal-append-to-body="false">
                <change-password-form @closeChangePasswordForm="closeChangePasswordForm" />
        </el-dialog>
    </div>
</template>

<script>
import UserProfileInfo from "./components/UserProfileInfo.vue";
import ChangePasswordForm from "./components/ChangePasswordForm.vue";
export default {
    components: { UserProfileInfo, ChangePasswordForm },
    data() {
        return {
            isChangePasswordFormVisible: false
        }
    },
    methods: {
        openChangePasswordForm() {
            this.isChangePasswordFormVisible = true;
        },
        closeChangePasswordForm() {
            this.isChangePasswordFormVisible = false;
        }
    }
}
</script>


<style scoped>

.profile-info-page {
    width: 60%;
    /* height: 50%; */
    margin-top: 10%;
}
</style>
