import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { MemberManagementComponent } from './member-management/member-management.component';
import { MemberConfigComponent } from './member-config/member-config.component';
import { MemberDetailComponent } from './member-management/member-detail/member-detail.component';

const routes: Routes = [
    {
        path: 'memberCenter',
        component: MemberManagementComponent,
        canActivate: [AppRouteGuard],
    },
    {
        path: 'member-detail/:id',
        component: MemberDetailComponent,
        canActivate: [AppRouteGuard],
    },
    {
        path: 'memberConfig',
        component: MemberConfigComponent,
        canActivate: [AppRouteGuard],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class MemberCenterRoutingModule { }
