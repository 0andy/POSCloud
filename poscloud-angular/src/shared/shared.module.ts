import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule, ModuleWithProviders } from '@angular/core';
import { AbpModule } from 'abp-ng2-module/dist/src/abp.module';
import { RouterModule } from '@angular/router';

import { AppSessionService } from '@shared/session/app-session.service';
import { AppUrlService } from '@shared/nav/app-url.service';
import { AppAuthService } from '@shared/auth/app-auth.service';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';

// delon
import { AlainThemeModule, ModalHelper } from '@delon/theme';
import { DelonABCModule } from '@delon/abc';
import { DelonACLModule } from '@delon/acl';
import { DelonFormModule } from '@delon/form';

// region: third libs
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { CountdownModule } from 'ngx-countdown';
import { HostUrlPipe } from './pipe/host-url.pipe';
import { LengthLimitPipe } from './pipe/length-limit.pipe';
import { KeyHighlightPipe } from './pipe/key-highlight.pipe';

const THIRDMODULES = [NgZorroAntdModule, CountdownModule];
const COMPONENTS = [HostUrlPipe, LengthLimitPipe, KeyHighlightPipe];
// endregion

@NgModule({
  imports: [
    CommonModule,
    AbpModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),

    AlainThemeModule.forChild(),
    DelonABCModule,
    DelonACLModule,
    DelonFormModule,
    // third libs
    ...THIRDMODULES,
  ],
  declarations: [
    ...COMPONENTS
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    AlainThemeModule,
    DelonABCModule,
    DelonACLModule,
    DelonFormModule,
    // third libs
    ...THIRDMODULES,
    ...COMPONENTS
  ],
  providers: [ModalHelper],
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [
        AppSessionService,
        AppUrlService,
        AppAuthService,
        AppRouteGuard,
      ],
    };
  }
}
