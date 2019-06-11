<template>
    <div class="profile-info-page">
        <user-profile-info 
            @openChangePasswordForm="openChangePasswordForm" />
        <el-dialog
            width="30%"
            title="Promena lozinke" center class="changePasswordForm"
            @close="closeChangePasswordForm" 
            :visible="isChangePasswordFormVisible" 
            :modal-append-to-body="false">
                <change-password-form 
                    @closeChangePasswordForm="closeChangePasswordForm" />
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
    margin-top: 10%;
    display: flex;
    flex-direction: column;
    align-content: center;
}

.changePasswordForm {
    /* width: 80%; */
}

</style>
