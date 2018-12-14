// Angular Imports
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { LayoutModule } from '@app/layout/layout.module';
import { SharedModule } from '@shared/shared.module';
import { AbpModule } from 'abp-ng2-module/dist/src/abp.module';
import { MemberManagementComponent } from './member-management/member-management.component';
import { MemberConfigComponent } from './member-config/member-config.component';
import { LocalizationService } from 'abp-ng2-module/dist/src/localization/localization.service';
import { MemberCenterRoutingModule } from './member-center-routing.module';
import { MemberDetailComponent } from './member-management/member-detail/member-detail.component';

// This Module's Components

@NgModule({
    imports: [
        CommonModule,
        HttpClientModule,
        LayoutModule,
        SharedModule,
        AbpModule,
        MemberCenterRoutingModule
    ],
    declarations: [
        MemberManagementComponent,
        MemberDetailComponent,
        MemberConfigComponent
    ],
    exports: [
    ],
    providers: [LocalizationService],
})
export class MemberCenterModule {

}
