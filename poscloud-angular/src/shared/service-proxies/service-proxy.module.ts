import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AbpHttpInterceptor } from 'abp-ng2-module/dist/src/abpHttpInterceptor';

import * as ApiServiceProxies from '@shared/service-proxies/service-proxies';
import { ProductServiceProxy } from './product-center/product.service';
import { PosCloudHttpClient } from './poscloud-httpclient';
import { RetailerServiceProxy } from './basic-data';
import { MemberServiceProxy } from './member-center';

@NgModule({
  providers: [
    ApiServiceProxies.RoleServiceProxy,
    ApiServiceProxies.SessionServiceProxy,
    ApiServiceProxies.TenantServiceProxy,
    ApiServiceProxies.UserServiceProxy,
    ApiServiceProxies.TokenAuthServiceProxy,
    ApiServiceProxies.AccountServiceProxy,
    ApiServiceProxies.ConfigurationServiceProxy,
    PosCloudHttpClient,
    ProductServiceProxy,
    RetailerServiceProxy,
    MemberServiceProxy,
    { provide: HTTP_INTERCEPTORS, useClass: AbpHttpInterceptor, multi: true },
  ],
})
export class ServiceProxyModule { }
